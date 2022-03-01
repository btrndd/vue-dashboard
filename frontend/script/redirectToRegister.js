import { registerForm } from "./registerForm.js";

const redirectToRegister = (edit) => {
  const ev = {
    target: {
      id: 'register',
    }
  };
  const url = ev.target.id;
  history.pushState({}, '', url + '.html');
  document.title = 'Cadastrar';
  registerForm(ev, edit);
}

export { redirectToRegister };