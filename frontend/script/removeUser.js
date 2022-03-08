import { redirectToUsers } from "./redirectToUsers.js";

const removeUser = async (ev) => {
  const { id } = ev.target;
  const request = await fetch(`https://localhost:7271/users/${id}`, {
    method: "DELETE"
  });
  const response = await request.json();
  console.log(response);
  redirectToUsers();
};

export { removeUser };