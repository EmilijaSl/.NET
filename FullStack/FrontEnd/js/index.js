document.querySelector('#login').addEventListener('submit', (event) =>{
    event.preventDefault();

    const loginRequest = {
        userName: event.target.name.value,
        password: event.target.password.value //paimta sitas is api internetinio psl ir modifikuota 
      };
      fetch('https://localhost:7194/api/Auth/Login',{
        method: 'POST',
        headers:{
            'Content-type':'application/json'
        },
        body: JSON.stringify(loginRequest)  //visa sita dalimi iki db iskvieciam savo api 
      })
      .then(response=>response.json())
      .then(result =>{
        if(result.errorMessage){
            alert(result.errorMessage);
            return;
        }
       else{
        sessionStorage.setItem('token', result.token);
        document.location.href='/weather.html'
      }
    })
.catch((error)=>alert(error));
});