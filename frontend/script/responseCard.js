
export const responseCard = (response) => {
  const main = document.querySelector('body');
  const container = document.createElement('div');
  const text = document.createElement('p');
  text.textContent = response.message;
  main.appendChild(container);
  container.appendChild(text);
  container.classList.add('request');
  const keys = Object.keys(response);
  if (keys[0] !== 'message') {
    container.classList.add('bad');
  } else if (keys[0] === null) {
    container.classList.add('bad');
  } else {
    container.classList.add('good');
  }
}