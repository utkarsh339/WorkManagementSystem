import { useSelector } from "react-redux";
import { Navigate } from "react-router-dom";
import type { RootState } from "../app/store";

interface Props {
  children: React.ReactNode;
  role?: string;
}

const ProtectedRoute = ({ children, role }: Props) => {
  const { token, role: userRole } = useSelector(
    (state: RootState) => state.auth,
  );

  if (!token) return <Navigate to="/" />;

  if (role && userRole !== role) return <Navigate to="/" />;
  return <>{children}</>;
};

export default ProtectedRoute;
