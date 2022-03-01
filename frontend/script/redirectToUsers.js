import { usersList } from './usersList.js';

export const redirectToUsers = () => {
  const ev = {
    target: {
      id: 'users',
    }
  };
  const url = ev.target.id;
  history.pushState({}, '', url + '.html');
  usersList(ev);
}