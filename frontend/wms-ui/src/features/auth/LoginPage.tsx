import { useState, useEffect } from "react";
import { useLoginMutation } from "./authApi";
import { useDispatch, useSelector } from "react-redux";
import { setCredentials } from "./authSlice";
import { useNavigate } from "react-router-dom";
import type { RootState } from "../../app/store";

const LoginPage = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const [login] = useLoginMutation();
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const { isAuthenticated, role } = useSelector(
    (state: RootState) => state.auth,
  );

  const handleLogin = async () => {
    try {
      const result = await login({ email, password }).unwrap();

      const payload = JSON.parse(atob(result.token.split(".")[1]));
      const role =
        payload["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];

      dispatch(
        setCredentials({
          token: result.token,
          role: role,
        }),
      );
    } catch {
      alert("Invalid credentials");
    }
  };

  useEffect(() => {
    if (!isAuthenticated) return;

    if (role === "Admin") navigate("/admin", { replace: true });
    else if (role === "Manager") navigate("/manager", { replace: true });
    else if (role === "Employee") navigate("/employee", { replace: true });
  }, [isAuthenticated, role, navigate]);

  return (
    <div style={{ padding: "40px" }}>
      <h2>Login</h2>

      <input placeholder="Email" onChange={(e) => setEmail(e.target.value)} />
      <br />
      <br />

      <input
        type="password"
        placeholder="Password"
        onChange={(e) => setPassword(e.target.value)}
      />
      <br />
      <br />

      <button onClick={handleLogin}>Login</button>
    </div>
  );
};

export default LoginPage;
