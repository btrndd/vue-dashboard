import { redirectToRegister } from "./redirectToRegister.js";
// import { redirectToUsers } from "./redirectToUsers";

// const getById = async (id) => {
//   const request = await fetch(`/users/${id}`);
//   const response = await request.json();
//   return response;
// }

// const setValues = (userData) => {
//   const keys = Object.keys(userData);
//   keys.forEach((key) => {
//     document.getElementById(`${key}`).value = userData[key];
//   });
// }

const changeUser = async (form, id) => {
  const formData = new FormData(form);
  
  const request = await fetch(`/users/${id}`, {
    method: "PUT",
    body: formData,
    headers: {
      "Content-type": "application/json; charset=UTF-8"
    }
  });
  const response = await request.json();
  console.log(response);
}

const editUser = (ev) => {
  const edit = ev.target.id;
  redirectToRegister(edit);
  // const userData = await getById(id);
  // setValues(userData);
  // const form = document.querySelector('.form');
  // await changeUser(form, id);
  // redirectToUsers();
}

export { editUser, changeUser };