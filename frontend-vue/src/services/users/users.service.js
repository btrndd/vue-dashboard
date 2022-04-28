import ApiService from "@/api/api.service";

const UsersService = {
  async list() {
    const { data } = await ApiService.get('users');
    return data;
  }
}

export default UsersService;