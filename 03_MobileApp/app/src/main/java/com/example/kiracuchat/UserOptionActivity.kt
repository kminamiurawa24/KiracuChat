package com.example.kiracuchat
import android.content.Intent
import android.os.Bundle
import android.widget.Button
import androidx.activity.ComponentActivity



class UserOptionActivity : ComponentActivity()  {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
            setContentView(R.layout.user_option)
        val backBtn: Button = findViewById(R.id.back_btn)
        val UserSetting: Button = findViewById(R.id.user_setting_btn)


        backBtn.setOnClickListener {
            startActivity(Intent(this,channel::class.java))
        }
        UserSetting.setOnClickListener {
            startActivity(Intent(this, UserSettingActivity::class.java))
        }
    }
}