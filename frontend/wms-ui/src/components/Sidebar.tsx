import { useSelector } from "react-redux";
import { Link } from "react-router-dom";
import type { RootState } from "../app/store";

const Sidebar = () => {
  const { role } = useSelector((state: RootState) => state.auth);

  return (
    <div
      style={{
        width: "220px",
        background: "#222",
        color: "white",
        padding: "20px",
      }}
    >
      <h3>WMS</h3>

      {role === "Admin" && (
        <>
          <Link to="/admin" style={{ display: "block", color: "white" }}>
            Dashboard
          </Link>
          <Link to="/admin/tasks" style={{ display: "block", color: "white" }}>
            Manage Tasks
          </Link>
          <Link to="/admin/users" style={{ display: "block", color: "white" }}>
            Users
          </Link>
        </>
      )}

      {role === "Manager" && (
        <>
          <Link to="/manager" style={{ display: "block", color: "white" }}>
            Dashboard
          </Link>
          <Link
            to="/manager/tasks"
            style={{ display: "block", color: "white" }}
          >
            Tasks
          </Link>
        </>
      )}
      {role === "Employee" && (
        <>
          <Link to="/employee" style={{ display: "block", color: "white" }}>
            Dashboard
          </Link>
          <Link
            to="/employee/tasks"
            style={{ display: "block", color: "white" }}
          >
            My Tasks
          </Link>
        </>
      )}
    </div>
  );
};

export default Sidebar;
