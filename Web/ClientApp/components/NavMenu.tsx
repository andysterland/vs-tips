import * as React from 'react';
import { NavLink, Link } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className='main-nav'>
                <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <Link className='navbar-brand' to={ '/' }>Visual Studio Tips & Tricks</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink exact to={ '/' } activeClassName='active'>
                                <span className='glyphicon glyphicon-random'></span> Random Tip
                            </NavLink>
                        </li>
                        <li>
                            <NavLink exact to={'/'} activeClassName=''>
                                <span className='glyphicon glyphicon-th-list'></span> All Tips
                            </NavLink>
                        </li>
                        <li>
                            <NavLink exact to={'/'} activeClassName=''>
                                < span className='glyphicon glyphicon-plus' ></span > Add Tip
                            </NavLink>
                        </li>
                        <li>
                            <NavLink exact to={'/'} activeClassName=''>
                                < span className='glyphicon glyphicon-pencil' ></span > Manage Tips
                            </NavLink>
                        </li>
                    </ul>
                </div>
            </div>
        </div>;
    }
}