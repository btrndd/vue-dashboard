import { registerForm } from "./registerForm.js";

const redirectToRegister = (id, edit) => {
  const ev = {
    target: {
      id: 'register',
    }
  };
  const url = ev.target.id;
  history.pushState({}, '', url + '.html');
  if (edit) {
    document.title = 'Editar';
  } else {
    document.title = 'Cadastrar';
  }
  
  registerForm(ev, id, edit);
}

export { redirectToRegister };