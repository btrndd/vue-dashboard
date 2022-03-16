export const searchUsers = (data, input) => {
  const filteredData = data.filter((user) => user.name.toLowerCase().includes(input.toLowerCase()));
  return filteredData;
};