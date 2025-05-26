export type OrderDto = {
    id: string;
    buyerId: string;
    carId: string;
    orderDate: string;
    buyerName: string;
    carName: string;
    type: string;
};

export type LoginRequest = {
    email: string;
    password: string;
};

// Тип пользователя (UserDto с бэка)
export type UserDto = {
    id: string;
    fullName: string;
    email: string;
    phoneNumber: string;
};

// Ответ от логина (токен + юзер)
export type LoginResponse = {
    token: string;
    user: UserDto;
};