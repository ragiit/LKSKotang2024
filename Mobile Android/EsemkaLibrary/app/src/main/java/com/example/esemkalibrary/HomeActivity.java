package com.example.esemkalibrary;

import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.os.Bundle;

import com.example.esemkalibrary.databinding.ActivityHomeBinding;
import com.google.android.material.tabs.TabLayout;

public class HomeActivity extends AppCompatActivity {

    private ActivityHomeBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        binding = ActivityHomeBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());
        switchFragment(new HomeFragment());

        binding.bottomNavigation.addOnTabSelectedListener(new TabLayout.OnTabSelectedListener() {
            @Override
            public void onTabSelected(TabLayout.Tab tab) {
                // Handle tab selected event
                switch (tab.getPosition()) {
                    case 0:
                        // Handle click on the first tab ("Home")
                        // Do something when the "Home" tab is selected
                        switchFragment(new HomeFragment());
                        break;
                    case 1:
                        // Handle click on the second tab ("My Bookmarks")
                        // Do something when the "My Bookmarks" tab is selected
                        switchFragment(new MyBookmarkFragment());
                        break;
                    case 2:
                        // Handle click on the third tab ("My Profile")
                        // Do something when the "My Profile" tab is selected
                        switchFragment(new AllUsersFragment());
                        break;
                    default:
                        break;
                }
            }

            @Override
            public void onTabUnselected(TabLayout.Tab tab) {
                // Handle tab unselected event
            }

            @Override
            public void onTabReselected(TabLayout.Tab tab) {
                // Handle tab reselected event
            }
        });

    }

    private void switchFragment(Fragment fragment) {
        // Get the FragmentManager
        FragmentManager fragmentManager = getSupportFragmentManager();
        // Begin the FragmentTransaction
        FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
        // Replace the contents of the frameLayout with the new fragment
        fragmentTransaction.replace(R.id.frameLayout, fragment);
        // Commit the FragmentTransaction
        fragmentTransaction.commit();
    }
}