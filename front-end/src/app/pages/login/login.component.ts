import { StorageService } from './../../services/storage/storage.service';
import { UsuarioService } from './../../services/usuario/usuario-service.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  loading: boolean = false;

  constructor(
    private router: Router,
    private usuarioService: UsuarioService,
    private storageService: StorageService,
  ) {}

  ngOnInit(): void {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      senha: new FormControl('', [Validators.required]),
      nome: new FormControl(''),
    });
  }

  get email() {
    return this.loginForm.get('email')!;
  }

  get senha() {
    return this.loginForm.get('senha')!;
  }

  login() {
    if (this.loginForm.invalid) return;
    this.loading = true;
    setTimeout(() => {
      this.usuarioService
        .login(this.email.value, this.senha.value)
        .subscribe((res) => {
          console.log(res);
          this.storageService.salvarUsuarioNaStorage(res);
          this.storageService.salvarTokenNaStorage(res.token);
          this.router.navigate(['/dashboard']);
        });
      this.loading = false;
    }, 1200);
  }
}
