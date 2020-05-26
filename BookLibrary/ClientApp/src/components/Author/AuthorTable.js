import React, { Component } from 'react';
import AuthorRow from './AuthorRow'
import { Link } from "react-router-dom"


export class AuthorTable extends Component {
    static displayName = this.name;

    constructor(props) {
        super(props);
        this.state = { authorList: [], loading: true };
    }

    componentDidMount() {
        this.populateListData();
    }

    static renderAuthorTable(authorList) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {authorList.map(author =>
                        <AuthorRow key={author.id} author={author} />
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AuthorTable.renderAuthorTable(this.state.authorList);

        return (
            <div>
                <h1 id="tabelLabel" >List of authors</h1>
                <Link style={{ textDecoration: 'none', color: '#212529' }} to={{ pathname: '/author-create' }}> Create new author </Link>
                {contents}
            </div>
        );
    }

    async populateListData() {
        const response = await fetch('/api/author/list');
        const data = await response.json();
        this.setState({ authorList: data, loading: false });
    }
}
export default AuthorTable