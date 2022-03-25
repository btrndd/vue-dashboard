import { removeUser } from "./removeUser.js";

export const confirmRemove = (event) => {
  const { id } = event.target;
  const main = document.querySelector('.main') || document.querySelector('.main-hidden');
  const container = document.createElement('div');
  container.classList.add('modal');
  const text = document.createElement('p');
  text.textContent = 'Você realmente deseja excluir este usuário?';
  container.appendChild(text);
  const confirmButton = document.createElement('button');
  confirmButton.textContent = 'Confirmar';
  confirmButton.classList.add('register-btn');
  confirmButton.id = id;
  const cancelButton = document.createElement('button');
  cancelButton.textContent = 'Cancelar';
  cancelButton.classList.add('cancel-btn');
  confirmButton.addEventListener('click', removeUser);
  cancelButton.addEventListener('click', () => {
    main.removeChild(container);
  })
  const btnWrapper = document.createElement('div');
  btnWrapper.classList.add('modal-wrapper');
  container.appendChild(btnWrapper);
  btnWrapper.appendChild(confirmButton);
  btnWrapper.appendChild(cancelButton);
  main.appendChild(container);
}