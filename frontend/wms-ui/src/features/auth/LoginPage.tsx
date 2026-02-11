import { useState } from "react";
import { useLoginMutation } from "./authApi";
import { useDispatch } from "react-redux";
import { setCredentials } from "./authSlice";
import { jwtDecode } from "jwt-decode";
import type { AppDispatch } from "../../app/store";

interface JwtPayload {
  role: string;
  exp: number;
}

const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const [login] = useLoginMutation();
  const dispatch = useDispatch<AppDispatch>();

  const handleLogin = async () => {
    try {
      const result = await login({ email, password }).unwrap();

      const decoded = jwtDecode<JwtPayload>(result.token);

      dispatch(
        setCredentials({
          token: result.token,
          role: decoded.role,
        }),
      );

      alert("Login successful");
    } catch {
      alert("Invalid credentials");
    }
  };

  return (
    <div style={{ padding: "40px" }}>
      <h2>Login</h2>

      <input
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />

      <br />

      <input
        type="password"
        placeholder="Password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />

      <br />

      <button onClick={handleLogin}>Login</button>
    </div>
  );
};

export default LoginPage;
