import { Injectable } from "@angular/core";
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HTTP_INTERCEPTORS,
} from "@angular/common/http";
import { Observable } from "rxjs";

const TOKEN_HEADER_KEY = "Token_Auth";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {

    let authReq = request;

    const token = localStorage.getItem(TOKEN_HEADER_KEY);

    if (token) {
      authReq = request.clone({
      headers: request.headers.set("Authorization", "Bearer "+token)
        // headers: request.headers.set("Authorization",token)
      });
      return next.handle(authReq);
    } else {
      //debugger
      return next.handle(request);
    }

  }
}
