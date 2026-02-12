import { useGetEmployeeDashboardQuery } from "./dashboardApi";
import Layout from "../../components/Layout";

const EmployeeDashboard = () => {
  const { data, isLoading, error } = useGetEmployeeDashboardQuery();

  if (isLoading) return <h2>Loading...</h2>;
  if (error) return <h2>Error loading dashboard</h2>;

  return (
    <Layout>
      <h2>Employee Dashboard</h2>
      <div style={{ padding: "20px" }}>
        <p>My Total Tasks: {data?.myTotalTasks}</p>
        <p>Completed Tasks: {data?.completedTasks}</p>
        <p>Pending Tasks: {data?.pendingTasks}</p>
      </div>
    </Layout>
  );
};

export default EmployeeDashboard;
