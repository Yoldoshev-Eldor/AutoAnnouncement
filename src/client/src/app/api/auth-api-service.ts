import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SignUpDto } from "./interfaces/sign-up-dto";
import { LoginDto } from "./interfaces/login-dto";
import { LoginResponseDto } from "./interfaces/login-response-dto";

@Injectable({ providedIn: 'root' })
export class AuthApiService {
  private readonly apiUrl = 'https://localhost:7035/api/auth';

  constructor(private http: HttpClient) { }

  public signUp(dto: SignUpDto): Observable<number> {
    const url = `${this.apiUrl}/signUp`;
    return this.http.post<number>(url, dto);
  }

  public login(dto: LoginDto): Observable<LoginResponseDto> {
    const url = `${this.apiUrl}/login`;
    return this.http.post<LoginResponseDto>(url, dto);
  }

  public refreshToken(refreshToken: string, accessToken : string): Observable<LoginResponseDto> {
    const url = `${this.apiUrl}/refresh-token`;
    return this.http.post<LoginResponseDto>(url, { refreshToken, accessToken });
  }

  public logout(refreshToken: string): Observable<void> {
    const url = `${this.apiUrl}/log-out`;
    return this.http.delete<void>(url, { body: { refreshToken } });
  }

  public testGetAll(): Observable<any> {
    const url = 'https://localhost:7088/api/todo-list/get-all?skip=0&take=20';
    return this.http.get<any>(url);
  }
}
