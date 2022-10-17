const token = sessionStorage.getItem('token');
if(!token){
    alert('please login');
    document.location.href='/index.html';
}
else{
    fetch('https://localhost:7194/WeatherForecast',{
        method: 'GET',
        headers:{
            'Authorization' : 'Bearer ' + token
        }
    })
    .then((response)=>response.json())
    .then((response)=>{
        const container = document.querySelector('#weather-container');
        
        for(let i = 0; i<response.length; i++){
            const weatherParagraph = document.createElement('p');
            weatherParagraph.innerHTML = `<b>${response[i].date}</b> temperature: <b>${response[i].temperatureC}</b>` //situs values pasiimam is backendo klasiu kur get set modeliai
            container.append(weatherParagraph);
        }
    })
    .catch((error)=>alert(error)); 
}