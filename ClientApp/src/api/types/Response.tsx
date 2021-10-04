export interface RegisterResponse {
    restaurantId: string,
    authToken: string
}
export interface AuthorizationResponse{
    token : string,
    restaurantName: string,
    isInitialized: boolean,
    email: string,
}