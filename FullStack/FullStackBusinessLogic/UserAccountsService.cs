using FullStackDAL;
using FullStackDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FullStackBL
{
    public class UserAccountsService : IUserAccountService
    {
        private readonly IDbRepository _dbRepository;
        public UserAccountsService(IDbRepository dbRepository) // depen injection tai kai priklausomybes injectiname i kita klase padupdami per konstruktoriu. 7.12+-
            
        { 
        _dbRepository = dbRepository;
        }

        public async Task<bool> CreateUserAccountAsync(string userName, string password, List<ContactDetail> contactDetails)
        {
            var existingUser = await _dbRepository.GetAccountByUserNameAsync(userName); //patikrinam ar jau nera tokio username
            if (existingUser != null)
            {
                return false;
            }

            var (hash, salt)=CreatePasswordHash(password);

            var newUser = new UserAccount
            {
                UserName = userName,
                ContactDetails = contactDetails,
                PasswordHash = hash,
                PasswordSalt = salt,
                Role = "User"
            };
            await _dbRepository.InsertAccountAsync(newUser);
            await _dbRepository.SaveChangesAsync();
            return true;
        }


        public async Task<(bool authentificationSuccesful, UserAccount? userAccount)> LoginAsync(string username, string password)
        {
            var account = await _dbRepository.GetAccountByUserNameAsync(username); //pasigrazinam accounta pagal username is db
            if (account == null)
            {
                return (false, null); //nerado accounto nieko negrazina
            }
            if (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt)) //patikrina passworda ir jeigu all good pagrazina accounta. metodas patikrinimui copy paste is jwt pask
            {
                return (true, account);
            }
            else
            {
                return (false, null);
            }


        }


        public (byte[] hash, byte[] salt) CreatePasswordHash(string password) //copy is jwt
        {
            using var hmac = new HMACSHA512(); //kriptografinis algoritmas
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return (hash, salt);
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //copy is jwt
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash); //cia bus palyginamas baitas su baitu
        }

    }
}
