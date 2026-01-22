"use client";
import { loginUser } from "@/app/services/authService";
import { useState } from "react";

import { Check } from "@gravity-ui/icons";
import { Button, Description, FieldError, Form, Input, Label, TextField } from "@heroui/react";

export default function LoginForm() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    try {
      const user = await loginUser(email, password);
      console.log("Usuário logado:", user);
    } catch (error) {
      console.error("Erro no login:", error);
    }
  };

  return (
    <Form className="flex w-96 flex-col gap-4" onSubmit={handleSubmit}>
      <TextField
        isRequired
        name="email"
        type="email"
        validate={(value) => {
          if (!/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(value)) {
            return "Por favor, insira um endereço de email válido";
          }
          return null;
        }}
      >
        <Label>Email</Label>
        <Input placeholder="joao@exemplo.com" value={email} onChange={(e) => setEmail(e.target.value)} />
        <FieldError />
      </TextField>
      <TextField
        isRequired
        minLength={8}
        name="password"
        type="password"
        validate={(value) => {
          if (value.length < 8) {
            return "Senha deve ter pelo menos 8 caracteres";
          }
          if (!/[A-Z]/.test(value)) {
            return "A senha deve conter pelo menos uma letra maiúscula";
          }
          if (!/[0-9]/.test(value)) {
            return "A senha deve conter pelo menos um número";
          }
          return null;
        }}
      >
        <Label>Senha</Label>
        <Input placeholder="Digite sua senha" value={password} onChange={(e) => setPassword(e.target.value)} />
        <Description>Deve ter pelo menos 8 caracteres com 1 letra maiúscula e 1 número</Description>
        <FieldError />
      </TextField>
      <div className="flex gap-2">
        <Button type="submit">
          <Check />
          Enviar
        </Button>
      </div>
    </Form>
  );
}