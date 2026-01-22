export const loginUser = async (email: string, password: string) => {
  const response = await fetch('https://api.seubackend.com/auth/login', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ email, password }),
  });

  if (!response.ok) {
    throw new Error('Falha no login');
  }

  return response.json();
}