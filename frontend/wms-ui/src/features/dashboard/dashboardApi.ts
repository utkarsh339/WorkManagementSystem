import { authApi } from "../auth/authApi";

export const dashboardApi = authApi.injectEndpoints({
  endpoints: (builder) => ({
    getAdminDashboard: builder.query<
      {
        totalUsers: number;
        activeUsers: number;
        totalTasks: number;
        completedTasks: number;
      },
      void
    >({
      query: () => "/dashboard/admin",
    }),
    getManagerDashboard: builder.query<
      {
        tasksCreatedByMe: number;
        pendingTasks: number;
        inProgressTasks: number;
        overdueTasks: number;
      },
      void
    >({
      query: () => "/dashboard/manager",
    }),
    getEmployeeDashboard: builder.query<
      {
        myTotalTasks: number;
        completedTasks: number;
        pendingTasks: number;
      },
      void
    >({
      query: () => "/dashboard/employee",
    }),
  }),
});

export const {
  useGetAdminDashboardQuery,
  useGetManagerDashboardQuery,
  useGetEmployeeDashboardQuery,
} = dashboardApi;
