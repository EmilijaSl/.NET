using DataAcces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    
        public class AuthService : IAuthService
        {
            private readonly IDatabaseRepository _repository;
            public AuthService(IDatabaseRepository repository)
            {
                _repository = repository;
            }
            public async Task<(bool authentificaltionSuccesfull, string? role)> LoginAsync(string username, string password)
            {
                var account = await _repository.GetAccauntAsync(username);
                if (account == null)
                {
                    return (false, null);
            }
            return (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt), account.Role);

        }

            public async Task<Accaunt> SignupNewAccauntAsync(string username, string password)
            {
                var account = CreateAccount(username, password);
                _repository.Add(account); //sita eilute butina kad pridetu i db SQL 
                await _repository.CommitAsync();
                return account;
            }


            private Accaunt CreateAccount(string username, string password)
            {
                (var passwordHash, var passwordSalt) = CreatePasswordHash(password);
                return new Accaunt //sukonstruoja account objekta. Kaip stringo nesaugome nes jeigu isilauztu galetu nusiskaityti slaptazodzius 
                {
                    Username = username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Role = "User"
                };
            }

            private (byte[] hash, byte[] salt) CreatePasswordHash(string password)
            {
                using var hmac = new HMACSHA512(); //kriptografinis algoritmas
                var salt = hmac.Key;
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return (hash, salt);
            }

            private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
            {
                using var hmac = new HMACSHA512(passwordSalt);
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash); //cia bus palyginamas baitas su baitu
            }

        public async Task<Accaunt> SaveUpdated(int id, string role) 
        {
            var acc = _repository.GetAccauntById(id);
            if (acc == null)
            {
                throw new ArgumentException($"Couldn't find account by Id {id}");
            }
            acc.Role = role;
            _repository.UpdateRoleAsync(acc);
            _repository.Commit();
            return acc;
            


        }
    }

    
}
