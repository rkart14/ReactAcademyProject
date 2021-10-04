import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { Register } from '../../api/AccountApi'
import { RegisterRequest } from '../../api/types/Request'
import './login.css'

export default function login() {
    function handleLogin(){
        Register({
            managerName : "revaz",
            email: "rkart14@freeuni.edu.ge",
            password: "password123"
        } as RegisterRequest).subscribe(res=> console.log(res));
    }
    return (
        <div className="login-form">
        <form>
            <h2 className="text-center">Log in</h2>       
            <div className="form-group">
                <input type="text" className="form-control" placeholder="Email" required/>
            </div>
            <div className="form-group">
                <input type="password" className="form-control" placeholder="Password" required/>
            </div>
            <div className="form-group">
                <button type="submit" className="btn btn-primary btn-block" onClick={handleLogin}>Log in</button>
            </div>
        </form>
        <Link to="/register">
            <p className="text-center"><a href="#">Register Restaurant</a></p>
        </Link>
    </div>
    )
}
