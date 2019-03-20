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
      isLoading : false,
      isCartToggled : false,
      isCheckoutToggled : false,
      cart : JSON.parse(localStorage.getItem('shoppingCart')) ? JSON.parse(localStorage.getItem('shoppingCart')) : []
    }
    this.addToCart = this.addToCart.bind(this)
    this.toggleCart = this.toggleCart.bind(this)
    this.clearCart = this.clearCart.bind(this)
    this.toggleCheckout = this.toggleCheckout.bind(this)

  }

  componentDidMount() {
    this.setState({ isLoading : true})

    axios.get(`/api/products`)
    // We get the API response and receive data in JSON format...
    .then(response => {
        this.setState({
          products: response.data,
          isLoading: false,
        })
      }
    )
  }

  addToCart(event, product) {
    event.preventDefault();
    this.setState((previousState) => {
      previousState.cart.push(product)
      localStorage.setItem('shoppingCart', JSON.stringify(previousState.cart));
      return {cart: previousState.cart};
    })

  }

  toggleCart() {
    this.setState(previousState => {
      return {isCartToggled : !previousState.isCartToggled}
    })
  }

  clearCart () {
    this.setState({cart:[]})
    localStorage.removeItem('shoppingCart')
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
