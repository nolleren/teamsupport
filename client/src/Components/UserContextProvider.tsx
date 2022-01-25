import React from 'react';
import { useQuery } from '@apollo/client';
import { loader } from 'graphql.macro';
import { GetCurrentUser, GetCurrentUser_currentuser } from '../GraphQL';

const GET_CURRENT_USER = loader('src/GraphQL/Users/GetCurrentUser.gql');

interface UserContextValues {
	user: GetCurrentUser_currentuser | null;
	loading: boolean;
}

const UserContext = React.createContext<UserContextValues>({
	user: null,
	loading: false,
});



export const UserContextProvider: React.FC = ({ children }) => {
	const { data, loading } = useQuery<GetCurrentUser>(GET_CURRENT_USER, {
		fetchPolicy: 'cache-and-network',
		nextFetchPolicy: 'cache-only',
	});



	const context: UserContextValues = {
		user: data?.currentuser ?? null,
		loading,
	};

	return (
		<UserContext.Provider value={context}>
			{children}
		</UserContext.Provider>
	);
};

export default UserContext;
