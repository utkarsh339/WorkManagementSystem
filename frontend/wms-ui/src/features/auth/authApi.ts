import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const authApi = createApi({
  reducerPath: "authApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://localhost:7112/api",
  }),
  endpoints: (builder) => ({
    login: builder.mutation<
      { token: string; expiresAt: string },
      { email: string; password: string }
    >({
      query: (body) => ({
        url: "/auth/login",
        method: "POST",
        body: body,
      }),
    }),
  }),
});

export const { useLoginMutation } = authApi;
