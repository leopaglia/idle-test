using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Bomb Weapon")]
public class BombWeapon : WeaponData
{
    public GameObject orbitingBombPrefab;

    public override void Shoot(Transform playerTransform, Transform spawnPoint, EquippedWeaponRuntime runtime)
    {
        //GameObject bomb = Instantiate(orbitingBombPrefab, playerTransform.position, Quaternion.identity);
        //bomb.transform.SetParent(playerTransform);

        //OrbitingProjectile orbit = bomb.GetComponent<OrbitingProjectile>();
        //if (orbit != null)
        //{
        //    orbit.Init(tier.bulletDamage, playerTransform);
        //}
    }
}

//using UnityEngine;

//public class OrbitingProjectile : MonoBehaviour
//{
//    public float orbitRadius = 1.5f;
//    public float orbitSpeed = 90f; // degrees per second
//    private Transform orbitCenter;
//    private float angle;
//    private int damage;

//    public void Init(int damage, Transform center)
//    {
//        this.damage = damage;
//        orbitCenter = center;
//        angle = Random.Range(0f, 360f); // start at a random angle
//    }

//    void Update()
//    {
//        if (orbitCenter == null)
//        {
//            Destroy(gameObject);
//            return;
//        }

//        angle += orbitSpeed * Time.deltaTime;
//        float rad = angle * Mathf.Deg2Rad;

//        Vector3 offset = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0) * orbitRadius;
//        transform.position = orbitCenter.position + offset;
//    }

//    // TODO: Add OnTriggerEnter2D to apply damage
//}
