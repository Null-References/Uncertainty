using Controller;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

public class PhysicalMovementTests
{
    [Test]
    public void AddNoForceToMovable()
    {
        IPhysicalMovable movable = Substitute.For<IPhysicalMovable>();
        float speed = 0;
        Vector3 direction = new Vector3(1, 0, 0);
       Transform gameObject = Substitute.For<Transform>();
        
        Rigidbody rb = Substitute.For<Rigidbody>();
        //rb.position = Vector3.zero;
        rb.re
        movable.Direction.Returns(direction);
        movable.Speed.Returns(speed);
        movable.Rigidbody.Returns(rb);

        PhysicalMovement physicalMovement = new PhysicalMovement(movable);
       // physicalMovement.Move();

        Assert.AreNotEqual(null, movable.Rigidbody);

    }
}
