import { useDispatch } from "react-redux";
import { logout } from "../features/auth/authSlice";
import { useNavigate } from "react-router-dom";

const Header = () => {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleLogout = () => {
    dispatch(logout());
    navigate("/", { replace: true });
  };

  return (
    <div style={{ padding: "20px", background: "#eee" }}>
      <button onClick={handleLogout}>Logout</button>
    </div>
  );
};

export default Header;
