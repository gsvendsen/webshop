import React, { Component } from 'react';
import Products from '../Products/'
import Cart from '../Cart/'
import Checkout from '../Checkout/'

import './App.css'

import axios from 'axios'

import './App.css';

class App extends Component {

  constructor() {
    super()
    this.state = {
      products : [],
      cartId : 1,
      isLoading : false,
      isCartToggled : false,
      isCheckoutToggled : false,
      cart : []
    }

    this.addToCart = this.addToCart.bind(this)
    this.toggleCart = this.toggleCart.bind(this)
    this.clearCart = this.clearCart.bind(this)
    this.toggleCheckout = this.toggleCheckout.bind(this)

  }

  componentDidMount() {
    this.setState({ isLoading : true})

    // Get all Products
    axios.get(`/api/products`)
      .then(response => {
          this.setState({
            products: response.data,
            isLoading: false,
          })
        }
      )

    this.updateCart()
  }

  updateCart() {

    fetch(`http://localhost:5000/api/cartitems/${this.state.cartId}`, {
      method: "GET",
      mode: "cors",
      headers: {
          "Content-Type": "application/json",
      }
    })
      .then(response => response.status !== 404 && response.json())
      .then(response => {
        this.setState({
          cart: response.length > 0 ? response : []
        })
      })
  }

  addToCart(event, product) {
    event.preventDefault();

    const data = {
      cart_id : this.state.cartId,
      product_id : product.id
    }

    fetch(`http://localhost:5000/api/cartitems/`, {
            method: "POST", // *GET, POST, PUT, DELETE, etc.
            mode: "cors", // no-cors, cors, *same-origin
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data), // body data type must match "Content-Type" header
        })
        .then(response => {
          this.updateCart()
        })
  }

  toggleCart() {
    this.setState(previousState => {
      return {isCartToggled : !previousState.isCartToggled}
    })
  }

  clearCart () {

    fetch(`http://localhost:5000/api/cartitems/${this.state.cartId}`, {
      method: "DELETE",
      mode: "cors",
      headers: {
          "Content-Type": "application/json",
      }
    })
      .then(response => {
        this.setState({
          cart: []
        })
      })

    this.toggleCart()
  }

  toggleCheckout () {
    this.setState(previousState => {
      return {isCheckoutToggled : !previousState.isCheckoutToggled}
    })
    this.toggleCart()
  }

  render() {
    return (
      <div className="App">
        {this.state.isCheckoutToggled ? <Checkout toggleCheckout={this.toggleCheckout} cart={this.state.cart} /> : "" }
        <div onClick={this.toggleCart} className="shopping-cart">
          <img alt="Shopping Cart" width="25" height="25" src="https://image.flaticon.com/icons/svg/2/2772.svg"></img>
          {this.state.cart.length}
        </div>
        {this.state.isCartToggled ? <Cart clearCart={this.clearCart} toggleCheckout={this.toggleCheckout} data={this.state.cart} /> : ""}
        {this.isLoading ? <p>Loading...</p> : <Products addToCart={this.addToCart} data={this.state.products} />}
      </div>
    );
  }
}

export default App;
