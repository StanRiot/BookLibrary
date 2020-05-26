import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';

import { BookTable } from './components/Book/BookTable'
import { BookEditForm } from './components/Book/BookEditForm'
import { BookCreateForm } from './components/Book/BookCreateForm'

import { GenreTable } from './components/Genre/GenreTable'
import { GenreEditForm } from './components/Genre/GenreEditForm'
import { GenreCreateForm } from './components/Genre/GenreCreateForm'

import { AuthorTable } from './components/Author/AuthorTable'
import { AuthorEditForm } from './components/Author/AuthorEditForm'
import { AuthorCreateForm } from './components/Author/AuthorCreateForm'

import './custom.css'

export default class App extends Component {
    static displayName = App.name;

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route path='/counter' component={Counter} />
                <Route path='/fetch-data' component={FetchData} />
                <Route path='/book-list' component={BookTable} />
                <Route path='/book-edit' component={BookEditForm} />
                <Route path='/book-create' component={BookCreateForm} />
                <Route path='/genre-list' component={GenreTable} />
                <Route path='/genre-edit' component={GenreEditForm} />
                <Route path='/genre-create' component={GenreCreateForm} />
                <Route path='/author-list' component={AuthorTable} />
                <Route path='/author-edit' component={AuthorEditForm} />
                <Route path='/author-create' component={AuthorCreateForm} />
            </Layout>
        );
    }
}
