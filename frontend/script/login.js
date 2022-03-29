import { isRequiredNew, verifyEmail, verifyPassword } from "./formValidation.js";
import { responseCard } from "./responseCard.js";
import { loadingSpinner } from "./loadingSpinner.js";
import { redirectToDash } from "./redirectToDash.js";
import { loginRequest } from "./loginRequest.js";

const callLogin = async  (email, password) => {  
  const response = await loginRequest(email, password);
  console.log(response);
  window.localStorage.setItem('auth', JSON.stringify(response.data));

  responseCard(response);
  const card = document.querySelector('.request');
  card.style.left = 0; 
  
  if (response.success === false) {
    if (card) {    
      setTimeout(() => {
        const parent = card.parentElement;
        parent.removeChild(card);
      }, 2000);
    }
    return;
  } else {
    redirectToDash(response);
  }
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
  
  const finalCheck = document.querySelectorAll('.warning');
  
  if (finalCheck.length === 0) {
    const main = document.querySelector('.login-container');
    
    loadingSpinner(main);
    const spinner = document.querySelector('.spinner');
    spinner.style.left = 0;
    
    await callLogin(email.value, password.value);
    
    const parent = spinner.parentElement;
    parent.removeChild(spinner);
  };
};

const loginBtn = document.querySelector('#login-btn');
loginBtn.addEventListener('click', login);