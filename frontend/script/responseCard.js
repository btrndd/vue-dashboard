
export const responseCard = (response) => {
  const main = document.querySelector('body');
  const container = document.createElement('div');
  const text = document.createElement('p');
  text.textContent = response.message;
  main.appendChild(container);
  container.appendChild(text);
  container.classList.add('request');
  if (!response.data || response.data === null) {
    container.classList.add('bad');
  } else {
    container.classList.add('good');
  }
}