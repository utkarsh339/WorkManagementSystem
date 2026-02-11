import { BrowserRouter, Routes, Route } from "react-router-dom";
import LoginPage from "../features/auth/LoginPage";

const AppRoutes = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<LoginPage />} />
      </Routes>
    </BrowserRouter>
  );
};

export default AppRoutes;
