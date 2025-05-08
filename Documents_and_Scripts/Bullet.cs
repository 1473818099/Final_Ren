using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 25f;

    private void OnCollisionEnter(Collision collision)
    {

        TargetEnemy enemy = collision.gameObject.GetComponent<TargetEnemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject);

        if (collision.gameObject.CompareTag("Target"));
        {
            print("hit" + collision.gameObject.name + "!");
            CreateBulletImpactEffect(collision);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            print("hits a wall");
            CreateBulletImpactEffect(collision);
            Destroy(gameObject);
        }
    }

    void CreateBulletImpactEffect(Collision objectHited)
    {
        ContactPoint contact = objectHited.contacts[0];

        GameObject hole = Instantiate(
            GlobalReferences.Instance.bulletImpactEffectPrefab,
            contact.point,
            Quaternion.LookRotation(contact.normal)
        );

        hole.transform.SetParent(objectHited.gameObject.transform);
    }

}
