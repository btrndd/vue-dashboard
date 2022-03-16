import { loadingSpinner } from "./loadingSpinner.js";
import { redirectToUsers } from "./redirectToUsers.js";
import { responseCard } from "./responseCard.js";

const removeUser = async (ev) => {
  const { id } = ev.target;
  const main = document.querySelector('.main') || document.querySelector('.main-hidden');
  loadingSpinner(main);
  const request = await fetch(`https://localhost:7271/users/${id}`, {
    method: "DELETE"
  });
  const response = await request.json();
  responseCard(response);
  redirectToUsers();
};

export { removeUser };