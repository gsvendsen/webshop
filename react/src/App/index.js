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
      isCartAnimated : false,
      cart : [],
      totalPrice : 0
    }

    this.addToCart = this.addToCart.bind(this)
    this.toggleCart = this.toggleCart.bind(this)
    this.clearCart = this.clearCart.bind(this)
    this.toggleCheckout = this.toggleCheckout.bind(this)
    this.animateCart = this.animateCart.bind(this)
    this.updatePrice = this.updatePrice.bind(this)

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

  updatePrice() {

    this.state.cart.forEach(item => {
      fetch(`http://localhost:5000/api/products/${item.product_id}`)
        .then(response => response.json())
        .then(response => {
          this.setState(previousState => {
            return {totalPrice : (previousState.totalPrice + response.price)}
          })
        })
    })
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
        this.updatePrice()
      })

  }

  animateCart () {
    this.setState({isCartAnimated : true})

    setTimeout(() => {
      this.setState({isCartAnimated : false})

    }, 500)
  }

  addToCart(event, product) {
    event.preventDefault();

    this.animateCart()

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
  }

  toggleCheckout () {
    this.setState(previousState => {
      return {isCheckoutToggled : !previousState.isCheckoutToggled}
    })
    this.toggleCart()
  }

  submitOrder (formData) {
    fetch(`http://localhost:5000/api/orders/1`, {
            method: "POST", // *GET, POST, PUT, DELETE, etc.
            mode: "cors", // no-cors, cors, *same-origin
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(formData), // body data type must match "Content-Type" header
    })
      .then(response => {
        this.clearCart();
      })
  }

  render() {
    return (
      <div className="App">
        <img className="logotype" src="https://i.imgur.com/CJ7QEi3.png"/>
        {this.state.isCheckoutToggled && <Checkout totalPrice={this.state.totalPrice} submitOrder={this.submitOrder} toggleCart={this.toggleCart} toggleCheckout={this.toggleCheckout} clearCart={this.clearCart} cart={this.state.cart} />}
        <div onClick={this.toggleCart} className={this.state.isCartAnimated ? 'shopping-cart animated' : 'shopping-cart'}>
          <img alt="Shopping Cart" width="25" height="25" src="https://image.flaticon.com/icons/svg/2/2772.svg"></img>
          {this.state.cart.length}
        </div>
        {this.state.isCartToggled && <Cart toggleCart={this.toggleCart} clearCart={this.clearCart} toggleCheckout={this.toggleCheckout} data={this.state.cart} />}
        {this.isLoading ? <p>Loading...</p> : <Products addToCart={this.addToCart} data={this.state.products} />}
      </div>
    );
  }
}

export default App;
