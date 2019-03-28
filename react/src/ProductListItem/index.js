import React, {Component} from 'react'

import './ProductListItem.css'

class ProductListItem extends Component {

  state = {
    productData: {}
  }

  componentDidMount() {

    fetch(`http://localhost:5000/api/products/${this.props.data}`)
      .then(response => response.json())
      .then(res => {
        this.setState({
          productData : res
        })
      })
  }

  render () {
    return (
      <div className="product-list-item">
        <img className="product-thumbnail" src={this.state.productData.image} alt={this.state.productData.description} />
        <div className="product-list-info">
          <p>{this.state.productData.name}</p>
          <p> ${this.state.productData.price}</p>
        </div>
      </div>
    )
  }
}

export default ProductListItem
