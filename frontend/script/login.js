import { isRequiredNew, verifyEmail, verifyPassword } from "./formValidation.js";
import { responseCard } from "./responseCard.js";
import { loadingSpinner } from "./loadingSpinner.js";
import { redirectToDash } from "./redirectToDash.js";

const callLogin = async  (email, password) => {
  const body = {
    email,
    password
  };
  
  const json = JSON.stringify(body);
  
  const request = await fetch("https://localhost:7271/login", {
    method: "POST",
    body: json,
    headers: {
      "Content-type": "application/json; charset=UTF-8"
    },
  });
  
  const response = await request.json();
  window.localStorage.setItem('auth', JSON.stringify(response.data));

  responseCard(response);
  redirectToDash(response);
};


const login = async () => {
  const inputs = document.querySelectorAll('.form-input');
  const email = inputs[0];
  const password = inputs[1];
  const smalls = document.querySelectorAll('.warning');
  
  if (smalls) {
    for (let index = 0; index < smalls.length; index += 1) {
      const parent = smalls[index].parentElement;
      parent.removeChild(smalls[index]);
    };
  };
  
  isRequiredNew();
  verifyEmail(email.value);
  verifyPassword(password.value);
  
  const finalCheck = document.querySelectorAll('.warning');
  
  if (finalCheck.length === 0) {
    const main = document.querySelector('.login-container');
    
    loadingSpinner(main);
    const spinner = document.querySelector('.spinner');
    spinner.style.left = 0;
    
    await callLogin(email.value, password.value);
    
    spinner.style.visibility = 'hidden';
  };
};

const loginBtn = document.querySelector('#login-btn');
loginBtn.addEventListener('click', login);