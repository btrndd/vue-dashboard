import ApiService from "@/api/api.service";

const UsersService = {
  async list() {
    const { data } = await ApiService.get('users');
    return data;
  },
  async save(form) {
    const { data } = await ApiService.post('users', {...form});
    return data;
  }
}

export default UsersService;