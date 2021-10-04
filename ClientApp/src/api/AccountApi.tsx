import { AuthenticationRequest, RegisterRequest } from "./types/Request";
import { ajax, AjaxResponse } from "rxjs/ajax";
import { serverAddress } from "../const";
import { map } from "rxjs";
import { RegisterResponse } from "./types/Response";

const address = serverAddress + "Account";


export function Register(request: RegisterRequest) {
    return ajax
      .post(address + "/Create", JSON.stringify(request), {
        Accept: "application/json",
        "Content-Type": "application/json"
      })
      .pipe(map(response=> {
          return response.response
      })
      );
  }

  export function Authenticate(request: AuthenticationRequest){
    return ajax
    .post(address + "/Create", JSON.stringify(request), {
      Accept: "application/json",
      "Content-Type": "application/json"
    })
    .pipe(map(response=> {
        return response.response
    })
    );
  }