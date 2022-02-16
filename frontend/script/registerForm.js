import { formValidation } from './formValidation.js';
import { formatNumber } from './phoneMask.js';
import { executeMask } from './phoneMask.js';

const main = document.querySelector('.main');

const formInjection = async (page) => {
  main.innerHTML = '';
  const newHtml = document.createElement('div');
  newHtml.innerHTML = page;
  const newMain = newHtml.querySelector('.main');
  main.innerHTML = newMain.innerHTML;
}

const getData = async(data) => {
  const request = new Request(data + '.html');
  const response = await fetch(request);
  const page = await response.text();
  return page;
}

const registerForm = async (ev) => {
  const { id } = ev.target;
  const response = await getData(id);
  await formInjection(response);
  const submitBtn = document.getElementById('cadastrar');
  if (submitBtn) {
    submitBtn.addEventListener('click', formValidation);
  }
  const phone = document.getElementById('phone');
  phone.addEventListener('keyup', () => {
    const adjustedPhone = formatNumber(phone.value);
    executeMask(phone, adjustedPhone);
  });
}

export { registerForm };