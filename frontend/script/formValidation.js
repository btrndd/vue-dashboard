import { formatNumber } from './phoneMask.js';
import { executeMask } from './phoneMask.js';

const submitBtn = document.getElementById('cadastrar');
const phone = document.getElementById('phone');

if (phone) {
  phone.addEventListener('keyup', () => {
    const adjustedPhone = formatNumber(phone.value);
    executeMask(phone, adjustedPhone);
  });
}

const verifyEmail = (email) => {
  if (email.value) {
    const regexEmail = /^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/;
    if (regexEmail.test(email.value)) {
      return true;
    }
    const warning = document.createElement('small');
    warning.textContent = 'Por favor, insira um email válido.'
    warning.classList.add('warning');
    const parent = email.parentElement;
    parent.appendChild(warning);
  }
}

const verifyPhone = (phone) => {
  if (phone.value) {
    const onlyNumbers = phone.value.replace(/\D/g, '');
    if (onlyNumbers.length >= 10) {
      return true;
    }
    const warning = document.createElement('small');
    warning.textContent = 'Por favor, insira um número válido.'
    warning.classList.add('warning');
    const parent = phone.parentElement;
    parent.appendChild(warning); 
  }  
}

const verifyPassword = (password) => {
  if (password.value) {
    const regex = /\d/g;
    const haveNumber = regex.test(password.value);
    if (password.value.length >= 6 && haveNumber) {
      return true;
    }
    const warning = document.createElement('small');
    warning.textContent = 'Sua senha precisa ter no mínimo 6 digitos e um número.'
    warning.classList.add('warning');
    const parent = password.parentElement;
    parent.appendChild(warning);  
  }  
}

const doubleCheckPassword = (password, checkPassword) => {
  if (checkPassword.value) {
    if (password.value === checkPassword.value) {
      return true;
    }
    const warning = document.createElement('small');
    warning.textContent = 'Por favor, verifique a senha inserida.'
    warning.classList.add('warning');
    const parent = checkPassword.parentElement;
    parent.appendChild(warning);  
  }  
}

const isRequired = () => {
  const inputs = document.getElementsByTagName('input');
  for (let index = 0; index < inputs.length; index += 1) {
    if (inputs[index].value !== '') {
      console.log('success');
    } else {
      const warning = document.createElement('small');
      warning.textContent = 'Por favor, preencha este campo.'
      warning.classList.add('warning');
      const parent = inputs[index].parentElement;
      parent.appendChild(warning);
    }    
  };
}

function formValidation() {
  const phone = document.getElementById('phone');
  const email = document.getElementById('email');
  const password = document.getElementById('password');
  const checkPassword = document.getElementById('checkPassword');
  const smalls = document.querySelectorAll('.warning');
  
  if (smalls) {
    for (let index = 0; index < smalls.length; index += 1) {
      const parent = smalls[index].parentElement;
      parent.removeChild(smalls[index]);
    }
  }
  isRequired();
  verifyEmail(email);
  verifyPassword(password);
  doubleCheckPassword(password, checkPassword);
  verifyPhone(phone);
  const finalCheck = document.querySelectorAll('.warning');
  if (finalCheck.length === 0) {
    return window.alert('Criado com sucesso!');
  }
}

if (submitBtn) {
  submitBtn.addEventListener('click', formValidation);
}

export { formValidation };
