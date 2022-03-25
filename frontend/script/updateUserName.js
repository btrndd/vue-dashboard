import { getById } from "./registerForm.js";

export const updateUserName = async (id) => {
  const userResponse = await getById(id);
  const user = document.querySelector('.user');
  user.textContent = userResponse.name + ' ' + userResponse.lastName;
}

