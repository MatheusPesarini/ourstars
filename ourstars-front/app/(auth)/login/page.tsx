import LoginForm from "./form";

export default function LoginPage() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-center p-24">
      <div className="w-full max-w-sm space-y-4">
        <LoginForm />
      </div>
    </main>
  )
}