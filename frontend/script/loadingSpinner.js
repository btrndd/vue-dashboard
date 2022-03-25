
export const loadingSpinner = (main) => {
  const spinner = document.createElement('div');
  spinner.classList.add('spinner');
  const spinnerContainer = document.createElement('div');
  spinnerContainer.classList.add('spinner-container');
  main.appendChild(spinnerContainer);
  spinnerContainer.appendChild(spinner);
  spinner.style.visibility = 'visible';
}