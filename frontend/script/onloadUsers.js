import { toggleArrow } from './toggleArrow.js';
import { usersList } from './usersList.js';

const onloadUsers = () => {
  const ev = {
    target: {
      id: 'users',
    }
  };
  toggleArrow(ev)
  const url = ev.target.id;
  history.pushState({}, '', url + '.html');
  usersList(ev);
}

window.onload = () => {
  onloadUsers();
}