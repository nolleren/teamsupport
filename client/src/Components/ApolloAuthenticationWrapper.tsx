import React from 'react';
import { ApolloClient, ApolloProvider, createHttpLink, InMemoryCache } from '@apollo/client';
import { setContext } from '@apollo/client/link/context';

const ApolloAuthenticationWrapper: React.FC = ({ children }) => {
	localStorage.setItem('token', 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjZiNDdkYTRlLTJlMGYtNGI0Yi04NTk5LThlNjgyMzk0YzcxNiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJjdXN0b21lcm9uZSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImN1c3RvbWVyb25lQGN1c3RvbWVyLm9yZyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkN1c3RvbWVyIiwiZXhwIjoxNjQzMTMwOTA2LCJpc3MiOiJTdXBwb3J0T25saW5lIiwiYXVkIjoiQVBJIn0.1P_mFonfv_47j_rl1Wk1hgYisLz1Hi5gnlD-3QYL5Jk');
	const httpLink = createHttpLink({
		uri: 'http://localhost:9006/graphql',
		credentials: 'same-origin',
	});

	const authLink = setContext(async (_, { headers }) => {
		// get the authentication token from local storage if it exists
		const appToken = localStorage.getItem('token');
		// return the headers to the context so httpLink can read them
		return {
			headers: {
				...headers,
				authorization: `Bearer ${appToken}`,
			},

		};
	});

	const apolloClient = new ApolloClient({
		link: authLink.concat(httpLink),
		cache: new InMemoryCache(),
	});

	return <ApolloProvider client={apolloClient}>{children}</ApolloProvider>;
};

export default ApolloAuthenticationWrapper;
