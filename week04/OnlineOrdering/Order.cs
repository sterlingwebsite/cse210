public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public double GetTotalCost()
    {
        double productTotal = 0;
        
        foreach (Product p in _products)
        {
            productTotal += p.GetTotalCost();
        }

        double shipping = _customer.LivesInUSA() ? 5 : 35;

        return productTotal + shipping;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";

        foreach (Product p in _products)
        {
            label += p.GetLabelLine() + "\n";
        }

        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{_customer.GetName()}\n{_customer.GetAddressString()}";
    }
}