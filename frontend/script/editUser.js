import { redirectToRegister } from "./redirectToRegister.js";
import { responseCard } from "./responseCard.js";

const changeUser = async (form, id) => {

  const formData = new FormData(form);
  let object = {};
  formData.forEach((value, key) => object[key] = value);
  if (object.status) {
    object.status = true;
  };
  delete object.checkPassword;
  delete object.password;
  const json = JSON.stringify(object);
  const request = await fetch(`https://localhost:7271/users/${id}`, {
    method: "PUT",
    body: json,
    headers: {
      "Content-type": "application/json; charset=UTF-8"
    }
  });
  const response = await request.json();
  console.log(response);
  responseCard(response);
}

const editUser = (ev) => {
  const id = ev.target.id;
  const edit = ev.target.getAttribute('data-name');
  redirectToRegister(id, edit);
}

export { editUser, changeUser };